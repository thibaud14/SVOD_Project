class StaticPagesController < ApplicationController
  def home
    if signed_in?
      redirect_to :action => 'content'
    end
  end

  def content
    if !signed_in?
      redirect_to :action => 'home'
    end
    @videosSuggestion = Video.find_all_by_type_video(params='Film')
    @videosCollection = Video.find_all_by_type_video(params='Serie')
    @videoCurrent = Video.find(1)
    @videosRated = Video.rated(5)
    @videosRecent = Video.recent(5)
  end

  def update_video_collection
    @videosSuggestion = Video.find_all_by_type_video(params='Film')
    @videosCollection = Video.find_all_by_type_video(params='Serie')
    @videoCurrent = Video.find(1)
    render :json => @videosCollection
  end

  def find
    if !params[:search].nil?
      render 'layouts/_top' do |page|
        page.replace_html 'find-result', :partial => 'find'
      end
    else
      redirect_to :back
    end
  end

  def help
  end

  def about
  end
end

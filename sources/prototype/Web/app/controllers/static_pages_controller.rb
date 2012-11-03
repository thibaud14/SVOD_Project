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
    @videosSuggestion = Video.find_all_by_type_video(params='Serie')
    @videosCollection = Video.find_all_by_type_video(params='Serie')
    @videoCurrent = Video.find(1)
    @videosRated = Video.rated(5)
    @videosRecent = Video.recent(5)
  end

  def update_video_collection
    @videosSuggestion = Video.find_all_by_type_video(params='Serie')
    @videosCollection = Video.find_all_by_type_video(params='Film')
    @videoCurrent = Video.find(1)
    respond_to do |wants|
      #wants.html { redirect_to products_url }
      wants.js do
        render :update do |page|
          # something like this ...
          page[dom_id('suggestions')].replace :partial => @videosCollection
          # OR maybe something like this ...
          #page[dom_id(@product, "price")].replace_html @product.price
        end
      end
    end
    #render :content do |page|
    #  page.replace_html 'suggestions', :partial => 'suggestions', :object => @videoCollection
    #end
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

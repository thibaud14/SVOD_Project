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
    @videosRated = Video.rated(5)
    @videosRecent = Video.recent(5)
  end

  def help
  end

  def about
  end
end

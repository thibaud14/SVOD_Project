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
    @videos = Video.find_all_by_type_video(params='Serie')
  end

  def help
  end

  def about

  end
end
